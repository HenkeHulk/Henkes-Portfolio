$(document).ready(function () {
    $('#deleteContact').click(function () {
        bootbox.confirm({
            message: 'Are you really sure that you want to delete this contact',

            buttons: {
                confirm: {
                    label: 'Yes',
                    className: 'btn-danger'
                },
                cancel: {
                    label: 'No',
                    className: 'btn-default'
                }
            },
            callback: '~/Contact/Delete'
        })
    })
})