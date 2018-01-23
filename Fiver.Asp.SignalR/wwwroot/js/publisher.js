(function () {

    let hubUrl = 'http://localhost:58178/reportsPublisher';
    let httpConnection = new signalR.HttpConnection(hubUrl);
    let hubConnection = new signalR.HubConnection(httpConnection);

    $("#reportName").on("keypress", function (e) {
        hubConnection.invoke("KeyStroke", String.fromCharCode(e.which));
    });

    $("#publishReport").click(function () {
        var reportName = $("#reportName").val();
        var dataJson = { name: reportName };

        $.ajax({
            type: "POST",
            url: "http://localhost:58178/api/reports",
            data: JSON.stringify(dataJson),
            contentType: "application/json; charset=UTF-8",
            dataType: 'json'
        }).done(function (response) {
            hubConnection.invoke("PublishReport", response);
            $("#reportName").val("");
        });
    });

    hubConnection.on("BroadcastMessage", data => {
        $("#message").text(data);
    });

    hubConnection.start();
})();