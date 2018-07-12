$(document).ready(function () {
  //  $('#example').dataTable();


    $('#example').DataTable({
        "processing": true,
       // "serverSide": true,
        "ajax": ({
            dataType: "json",
            url: '/home/dataTable',
            type: 'post',
           // data: { "ConsularMappingId": null }
        }),
        "columns": [
            {
                "data": "CONSULAR_MAPPING_ID"
            },
            {
                "data": "PASSPORT_COUNTRY_CODE"
            },
            {
                "data": "PASSPORT_COUNTRY_NAME"
            },
            {
                "data": "COUNTRY_OF_RESIDENCE"
            },
            {
                "data": "COUNTRY_OF_RESIDENCE_NAME"
            },
            {
                "data": "CONSULAR_NAME"
            },
        ],
        scrollY: '50vh',
        scrollCollapse: true,
    });
});