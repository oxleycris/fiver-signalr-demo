(function () {

    let hubUrl = "http://localhost:58178/reportsPublisher";
    let httpConnection = new signalR.HttpConnection(hubUrl);
    let hubConnection = new signalR.HubConnection(httpConnection);

    $("#clear").click(function () {
        $("keyStrokes").val("");
    });

    hubConnection.on("OnKeyStroke", data => {
        var currentValue = $("#keyStrokes").val();

        $("#keyStrokes").val(currentValue + data);
    });

    hubConnection.start();
})();