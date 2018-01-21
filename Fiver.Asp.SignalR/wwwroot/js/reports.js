(function () {

    let hubUrl = "http://localhost:58179/reportsPublisher";
    let httpConnection = new signalR.HttpConnection(hubUrl);
    let hubConnection = new signalR.HubConnection(httpConnection);


    hubConnection.on("OnReportPublished", data => {
        var stuff = data.DateAdded + " - " + data.Name;

        $("#reports").append($("<li>").text(stuff));
    });

    hubConnection.start();
})();