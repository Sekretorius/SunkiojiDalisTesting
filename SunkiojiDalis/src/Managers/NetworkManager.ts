
//import index =  require("../index")
import { Console } from "console";
import { ClientObjects, ClientEngineMethods } from "./ClientEngine"

export function ProccessServerRequests(requests: any){
    for(const request of requests) {
        let requestData = null;
        if(request.RequestData)
        {
            requestData = JSON.parse(request.RequestData);
        }
        let serverRequest = new NetworkRequest(request.RequestObjectGuid, request.RequestMethod, requestData);
        HandleServerRequests(serverRequest);
    }
}

function HandleServerRequests(serverRequest: NetworkRequest) {
    let targetObject = ClientObjects[serverRequest.RequestObjectGuid];
    if(targetObject == undefined || !InvokeObjectMethod(targetObject, serverRequest.RequestMethod, serverRequest))
    {
        InvokeObjectMethod(ClientEngineMethods, serverRequest.RequestMethod, serverRequest);
    }
}

function InvokeObjectMethod(targetObject: any, method: any, data: any): boolean {
    if(targetObject !== undefined){
        if(targetObject[method] !== undefined){
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

export class NetworkRequest{
    RequestObjectGuid: string;
    RequestMethod: string;
    RequestData: string;

    constructor(requestObjectGuid: string, requestMethod: string, requestData: string){
        this.RequestObjectGuid = requestObjectGuid;
        this.RequestMethod = requestMethod;
        this.RequestData = requestData;
    }
}
