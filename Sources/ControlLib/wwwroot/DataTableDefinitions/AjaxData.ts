interface DataTableAjaxDataColumn {
    name: string;
    data: string;
}

interface DataTableAjaxData {
    draw: number;
    columns: DataTableAjaxDataColumn[];
    start: number;
    length: number;
}