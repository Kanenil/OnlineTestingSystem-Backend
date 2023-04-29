import { instance } from '@/api/api.interceptor'
import { ILogin, IRegister, IAuthResponse } from '@/store/user/user.interface'
import { saveToStorage } from './account.helper'

export const AccountService = {
	async login(data: ILogin) {
		const response = await instance<IAuthResponse>({
			url: '/account/login',
			method: 'POST',
			data,
		})

		if (response.data.token) saveToStorage(response.data)

		return response.data
	},

	async register(data: IRegister) {
		const response = await instance<IAuthResponse>({
			url: '/account/register',
			method: 'POST',
			data,
		})

		if (response.data.token) saveToStorage(response.data)

		return response.data
	},
}
