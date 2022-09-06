import http from "../http-common";
import IChangePasswordData from "../types/ChangePassword";
import IEditUserData from "../types/EditUser";
import IRegisterData from "../types/Register";
import ILoginData from "../types/Register";

const getUserById = (id: any) => {
    return http.get<IRegisterData>(`/User/GetByUserId/${id}`);
};

const getAllUsers = () => {
    return http.get<Array<IRegisterData>>("/User/GetAllUsers");
};

const register = (data: IRegisterData) => {
    return http.post<IRegisterData>("/User/Register", data);
};

const login = (data: ILoginData) => {
    return http.post<ILoginData>("/User/Login", data);
};

const editUser = (data: IEditUserData) => {
    return http.post<IEditUserData>("/User/EditProfile", data);
};

const changePassword = (data: IChangePasswordData) => {
    return http.post<IChangePasswordData>("/User/ChangePassword", data);
};

const UserService = {
    register,
    login,
    getUserById,
    getAllUsers,
    editUser,
    changePassword
};
export default UserService;