function GeneraDataTable(a, idTab) {
    $(idTab == undefined ? "table" : idTab).DataTable({
        serverSide: !1,
        processing: !1,
        paging: !0,
        searching: !0,
        columnDefs: [
            {
                targets: [a], orderable: !1, searchable: !1
            }],
        language: { url: "/json/italian.json" },
        createdRow: function (a) { $(a).children().each(function () { $(this).addClass("text-center align-middle") }) }
    })

}

