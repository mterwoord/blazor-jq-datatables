"use strict";
class DataTableCallbackWrapper {
    constructor(callback) {
        this.callback = callback;
    }
    getDataAsync(info) {
        return this.callback.invokeMethodAsync('GetData', info);
    }
}
async function dataTable_initializeDataTable(containerElement, tableElement, columns, callbackObject) {
    //debugger;
    var callbackWrapper = new DataTableCallbackWrapper(callbackObject);
    //tableElement
    $(tableElement).dataTable({
        serverSide: true,
        ordering: false,
        searching: false,
        columns: [
            {
                name: "message",
                title: "Message",
                data: row => row['message']
            },
            {
                name: "count",
                title: "Count",
                data: row => row['count']
            }
        ],
        ajax: (data, callback, settings) => {
            return dataTable_doAjaxCall(tableElement, callbackWrapper, data, callback, settings);
        },
        paging: true,
        scrollY: "400px",
        scroller: true,
        scrollCollapse: true
    });
}
function dataTable_cleanupTwDataTable(containerElement, tableElement) {
    var tableElem = $(tableElement);
    var containerElem = $(containerElem);
    setTimeout(() => {
        var x = tableElem;
        x.DataTable().destroy(true);
        containerElem.remove();
    });
    //debugger;
    // (<any>$(tableElement).dataTable()).api().destroy(true);
    // $(tableElement).remove();
    // $(containerElement).remove();
}
async function dataTable_doAjaxCall(tableElement, callbackWrapper, data, callback, settings) {
    var getDataInfo = {
        columns: data.columns.map(i => ({
            columnName: i.name,
            expression: i.data
        })),
        skip: data.start,
        take: data.length
    };
    callbackWrapper.getDataAsync(getDataInfo).then(r => {
        callback(r);
    });
}
