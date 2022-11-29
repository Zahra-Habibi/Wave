var dataTable;
var connectionJob = new signalR.HubConnectionBuilder().withUrl("/hubs/Job").build();

connectionOrder.on("Index", () => {
    dataTable.ajax.reload();
    toastr.success("New Job recived");
});

function fulfilled() {
    //do something on start
}
function rejected() {
    //rejected logs
}

connectionOrder.start().then(fulfilled, rejected);

