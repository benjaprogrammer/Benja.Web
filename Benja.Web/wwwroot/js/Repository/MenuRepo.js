class MenuRepo extends BaseRepo {
    header = "";
    constructor(token) {
        super();
        this.header = {
            headers: {
                "Content-Type": "application/json",
                "Authorization": "Bearer " + token
            }
        }
    }

    Add(menuVm) {
        try {
            const response = axios.post(this.BaseUrl + "/api/v1/menu/add", JSON.stringify(menuVm), this.header);
        } catch (error) {
            console.error(error);
        }
    }
    GetItem(menuVm) {
        try {
            const response = axios.get(this.BaseUrl + "/api/v1/menu/getitem" + "?menuModel=" + menuVm.menuModel.menuName);
            return JSON.parse(response);
        } catch (error) {
            console.error(error);
        }
    }
}
