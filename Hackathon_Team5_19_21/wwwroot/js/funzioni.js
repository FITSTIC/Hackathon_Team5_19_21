function GeneraDataTableModuli() {
    $("table").each(function () {
        $(this).DataTable({
            "paging": true,
            "searching": true,
            "columnDefs": [
                {
                    "targets": [7, 8],
                    "orderable": false,
                    "searchable": false
                }],
            "language": {
                "url": "/json/italian.json"
            },
            "createdRow": function (row) {
                $(row).children().each(function () { $(this).addClass("text-center align-middle"); });
            }
        })
    })
}

function GeneraDataTablePersonale() {

    $("table").DataTable({
        "paging": true,
        "searching": true,
        "columnDefs": [
        {
            "targets": [8, 9],
            "orderable": false,
            "searchable": false
        }],
        "language": {
            "url": "/json/italian.json"
        },
        "createdRow": function (row, meta) {
            $(row).children().each(function () { $(this).addClass("text-center align-middle"); });
        }
    })
}

function GeneraDataTableCorsi() {

    $("table").DataTable({
        "paging": true,
        "searching": true,
        "columnDefs": [
            {
                "targets": [6, 7],
                "orderable": false,
                "searchable": false
            }],
        "language": {
            "url": "/json/italian.json"
        },
        "createdRow": function (row, meta) {
            $(row).children().each(function () { $(this).addClass("text-center align-middle"); });
        }
    })
}