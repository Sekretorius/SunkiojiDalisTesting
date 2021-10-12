
connection.on("ClientRequestHandler", function (requests) {
    let requestValues = JSON.parse(requests);
    if (requestValues.length > 0) {
        ProccessServerRequests(requestValues);
    }
});

function ProccessServerRequests(requests){
    for(const request of requests) {
        let requestData = JSON.parse(request.RequestData);
        let serverRequest = new NetworkRequest(request.RequestObjectGuid, request.RequestMethod, requestData);
        HandleServerRequests(serverRequest);
    }
}

function HandleServerRequests(serverRequest) {
    let targetObject = ClientObjects[serverRequest.RequestObjectGuid];
    if(!InvokeObjectMethod(targetObject, serverRequest.RequestMethod, serverRequest)){
        InvokeObjectMethod(ClientEngineMethods, serverRequest.RequestMethod, serverRequest);
    }
}

function InvokeObjectMethod(targetObject, method, data) {
    if(targetObject !== undefined){
        if(targetObject[method] !== undefined){
            targetObject[method](data);
            return true;
        }
    }
    return false;
}

function SendRequestToServer(requests){
    connection.invoke("HandleClientRequest", JSON.stringify(requests)).catch(function (err) {
        return console.error(err.toString());
      });
}

class NetworkRequest{

    constructor(requestObjectGuid, requestMethod, requestData){
        this.RequestObjectGuid = requestObjectGuid;
        this.RequestMethod = requestMethod;
        this.RequestData = requestData;
    }
}
