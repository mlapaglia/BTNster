$(document).ready(function() {
    $('#selectContainers, #selectSources, #selectCodecs, #selectResolutions').multiselect({
        buttonWidth: '100%'
    });
    $('#toggle-one').bootstrapToggle();

    $('.input-group.date').datepicker({
    });

    $('#tableSeries').on('click', '.btn-danger', function () {
        $(this).parent().parent().remove();
    });

    $('#tableSeries').on('click', '.btn-primary', function () {
        var row = $(this).parent().parent().clone();
        row.find('.glyphicon-plus').removeClass('glyphicon-plus').addClass('glyphicon-trash');
        row.find('.btn-primary').removeClass('btn-primary').addClass('btn-danger');

        $('#tableSeries tr:last').before(row);

        $('#tableSeries tr:last').find('input').val('');
    });

    $('#buttonCancel').click(function () {
        window.location.href = '/Filters';
    });
});