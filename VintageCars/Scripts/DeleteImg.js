$(document).ready(function () {
    var firstTr;
    var Id;

    $(".deleteBtn").click(function () {
        firstTr = $(this).closest('tr');
        Id = firstTr.find('td:first').html();


        $('#confirmDelete').on("click", function () {
            $.ajax({
                url: '/Administrator/Delete',
                method: 'POST',
                data: { 'Id': Id },
                success: function (response) {
                    if (response == "DeleteSucceeded") {
                        $('.PostedData').trigger('click');
                        window.location.href = "/Administrator/Adminpanel";
                    }
                }
            });
        });

    });
});