var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url":"/Admin/Company/GetAll"
        },
        "columns": [
            { "name": "name", "data": "name", "width": "15%" },
            { "data": "streetAdress", "width": "15%" },
            { "data": "city", "width": "15%" },
            { "data": "postalCode", "width": "15%" },
            { "data": "phoneNumber", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <div class="w-75 btn-group" role="group">
                        <a href="/Admin/Company/Upsert?id=${data}"
                        class="btn btn-success mx-2"> <i class="bi bi-pencil-square"></i>Edytuj</a>
                        <a onClick=Delete('/Admin/Company/Delete/${data}')
                        class="btn btn-danger mx-2"> <i class="bi bi-trash"></i>Usuń</a>
                    </div>
                        `
                },
                "width" : "15 % "
            },
            ]
        });
}

function Delete(url) {
    Swal.fire({
        title: 'Jesteś pewien?',
        text: "Nie będziesz mógł przywrócić akcj!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Tak, skasuj!'
    }).then((result) => {
        $.ajax({
            url: url,
            type: 'DELETE',
            success: function (data) {
                if (data.success) {
                    dataTable.ajax.reload();
                    toastr.success(data.message);
                }
                else {
                    toastr.error(data.message);
                }
            }
        })
    });
}