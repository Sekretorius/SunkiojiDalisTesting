"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.NetworkRequest = exports.ProccessServerRequests = void 0;
var ClientEngine_1 = require("./ClientEngine");
function ProccessServerRequests(requests) {
    for (var _i = 0, requests_1 = requests; _i < requests_1.length; _i++) {
        var request = requests_1[_i];
        var requestData = null;
        if (request.RequestData) {
            requestData = JSON.parse(request.RequestData);
        }
        var serverRequest = new NetworkRequest(request.RequestObjectGuid, request.RequestMethod, requestData);
        HandleServerRequests(serverRequest);
    }
}
exports.ProccessServerRequests = ProccessServerRequests;
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
//function SendRequestToServer(requests: any){
//    connection.invoke("HandleClientRequest", JSON.stringify(requests)).catch(function (err) {
//        return console.error(err.toString());
//      });
//}
var NetworkRequest = /** @class */ (function () {
    function NetworkRequest(requestObjectGuid, requestMethod, requestData) {
        this.RequestObjectGuid = requestObjectGuid;
        this.RequestMethod = requestMethod;
        this.RequestData = requestData;
    }
    return NetworkRequest;
}());
exports.NetworkRequest = NetworkRequest;
