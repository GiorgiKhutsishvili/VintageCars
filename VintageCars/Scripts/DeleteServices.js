$(document).ready(function () {
    var firstTr;
    var Id;

    $(".srvcDeleteBtn").click(function () {
        firstTr = $(this).closest('tr');
        Id = firstTr.find('td:first').html();

        $("#confirmDeleteService").on("click", function () {
            $.ajax({
                url: '/Administrator/DeleteServices',
                method: 'POST',
                data: { 'Id': Id },
                success: function (response) {
                    if (response == "ServiceDeleteSucceeded") {
                        $('.servicesPostedData').trigger('click');
                        window.location.href = "/Administrator/Adminpanel";
                    }
                }
            });
        });
    });
});