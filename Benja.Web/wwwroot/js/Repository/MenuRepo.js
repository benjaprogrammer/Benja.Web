
class MenuRepo extends BaseRepo {
    constructor(token) {
        super();
        //super.Token = token;
        /*this.headers.Add("Authorization", "Bearer " + this._token)*/
    }

    Add(menuVm) {
        try {
            console.log(this.headers);
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
