class DataTableCallbackWrapper{
    constructor(private callback){

    }

    public getDataAsync(info: IGetDataCallArgumentModel): Promise<string> {
        return this.callback.invokeMethodAsync('GetData', info);
    }
}