class RegisterRepo extends BaseRepo {
    constructor(token) {
        super();
        this.header = {
            headers: {
                "Content-Type": "application/json",
                "Authorization": "Bearer " + token
            }
        }
    }

    Registers(registerModel) {
        try {
            const response = axios.post(this.BaseUrl + "/authen/register", JSON.stringify(registerModel), this.header).then((response) => {
                return response;
            });
        } catch (error) {
            console.error(error);
        }
    }
}
