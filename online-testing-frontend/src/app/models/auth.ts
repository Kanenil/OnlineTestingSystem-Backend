export interface IUser {
  id:number,
  userName: string,
  email: string,
  image: string
}

export interface IAuthResponse {
  token: string
}

export interface IRegisterUser {
  firstName:string,
  lastName: string,
  email: string,
  userName: string,
  password: string,
  confirmPassword: string,
}

