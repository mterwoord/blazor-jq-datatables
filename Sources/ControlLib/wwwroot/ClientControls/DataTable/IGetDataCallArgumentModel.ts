interface IGetDataCallColumnModel{
    columnName: string;
    expression: string;
}
interface IGetDataCallArgumentModel {
    columns: IGetDataCallColumnModel[];
    skip: number;
    take: number;
}