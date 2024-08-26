
class MenuRepo extends BaseRepo {
    constructor(token) {
        super();
        _token = token;
        this.headers.Add("Authorization", "Bearer " + _token)
    }

    Add(menuVm) {
        try {
            const response = axios.post(this.BaseUrl + "/api/v1/menu/add", JSON.stringify(menuVm), this.headers);
        } catch (error) {
            console.error(error);
        }
    }
    GetItem(menuVm) {
        try {
            const response = axios.get(this.BaseUrl + "/api/v1/menu/getitem" + "?menuModel=" + menuVm.menuModel.menuName);
        } catch (error) {
            console.error(error);
        }
    }
}
