import { IAuthResponse, IInitState, IToken } from '@/store/user/user.interface'
import { IUser } from '@/types/user.interface'
import Cookies from 'js-cookie'
import { decodeToken } from 'react-jwt'

export const saveTokenStorage = (token: string) => {
	const decodedToken = decodeToken<IToken>(token)

	Cookies.set('token', token, { expires: decodedToken?.expires })
}

export const getToken = () => {
	const token = Cookies.get('token')
	return token || null
}

export const getUserFromStorage = () => {
	return JSON.parse(localStorage.getItem('user') || '{}')
}

export const removeFromStorage = () => {
	Cookies.remove('token')
	localStorage.removeItem('user')
}

export const saveToStorage = (data: IAuthResponse) => {
	const myDecodedToken = decodeToken<IInitState>(data.token)

	saveTokenStorage(data.token)

	localStorage.setItem('user', JSON.stringify(myDecodedToken))

	return myDecodedToken
}
