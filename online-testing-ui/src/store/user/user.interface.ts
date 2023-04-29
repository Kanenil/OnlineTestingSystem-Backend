import { IUser } from '@/types/user.interface'

export interface IUserState {
	name: string
	email: string
	emailConfirmed: boolean
	image: string | null
}

export interface IToken extends IUser {
	expires: Date
	roles: string[]
}

export interface IAuthResponse {
	token: string
}

export interface IAuthUserResponse {
	user: IUserState | null
}

export interface IInitState {
	user: IUserState | null
	isLoading: boolean
}

export interface ILogin {
	email: string
	password: string
}

export interface IRegister {
	firstName: string
	lastName: string
	email: string
	userName: string
	password: string
}
