"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.NetworkRequest = void 0;
var index_1 = require("../index");
var ClientEngine_1 = require("./ClientEngine");
index_1.connection.on("ClientRequestHandler", function (requests) {
    var requestValues = JSON.parse(requests);
    if (requestValues.length > 0) {
        ProccessServerRequests(requestValues);
    }
});
function ProccessServerRequests(requests) {
    for (var _i = 0, requests_1 = requests; _i < requests_1.length; _i++) {
        var request = requests_1[_i];
        var requestData = JSON.parse(request.RequestData);
        var serverRequest = new NetworkRequest(request.RequestObjectGuid, request.RequestMethod, requestData);
        HandleServerRequests(serverRequest);
    }
}
function HandleServerRequests(serverRequest) {
    var targetObject = ClientEngine_1.ClientObjects[serverRequest.RequestObjectGuid];
    if (targetObject == undefined || !InvokeObjectMethod(targetObject, serverRequest.RequestMethod, serverRequest)) {
        InvokeObjectMethod(ClientEngine_1.ClientEngineMethods, serverRequest.RequestMethod, serverRequest);
    }
}
function InvokeObjectMethod(targetObject, method, data) {
    if (targetObject !== undefined) {
        if (targetObject[method] !== undefined) {
            targetObject[method](data);
            return true;
        }
    }
    return false;
}
function SendRequestToServer(requests) {
    index_1.connection.invoke("HandleClientRequest", JSON.stringify(requests)).catch(function (err) {
        return console.error(err.toString());
    });
}
var NetworkRequest = /** @class */ (function () {
    function NetworkRequest(requestObjectGuid, requestMethod, requestData) {
        this.RequestObjectGuid = requestObjectGuid;
        this.RequestMethod = requestMethod;
        this.RequestData = requestData;
    }
    return NetworkRequest;
}());
exports.NetworkRequest = NetworkRequest;
