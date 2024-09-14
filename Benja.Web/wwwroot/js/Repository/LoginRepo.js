class LoginRepo extends BaseRepo {
    constructor(token) {
        super();
        this.header = {
            headers: {
                "Content-Type": "application/json",
                "Authorization": "Bearer " + token
            }
        }
    }

    Login(loginRequestModel) {
        try {
            const response = axios.post(this.BaseUrl + "/authen/login", JSON.stringify(loginRequestModel), this.header).then((response) => {
                return response.data.data.accessToken;
            });

        } catch (error) {
            console.error(error);
        }
    }
}
