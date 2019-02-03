/* Page Load */
$(document).ready(function () {
    $('#tblAssessments').dataTable({

        paging: false,
        ordering: false,
        select: true,
        searching: true

    });

    $('#divSelectAssessment').hide();
});


$('#btnSubmitUser').on('click', function () {
    $('#divSelectAssessment').show();
});