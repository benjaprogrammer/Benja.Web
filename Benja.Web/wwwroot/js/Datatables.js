class Datatables {
    data = [];
    recordsFiltered = 0;
    recordsTotal = 0;
    constructor() {
    }
    static BindData(response, recordsFiltered, recordsTotal, tableID) {
        this.data = JSON.stringify(response);
        this.recordsFiltered = recordsFiltered;
        this.recordsTotal = recordsTotal;

        tableID.ajax = JSON.stringify(this);
    }
}

