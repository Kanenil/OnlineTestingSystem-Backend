import axios from 'axios'
import { errorCatch, getContentType } from './api.helper'
import { getToken, removeFromStorage } from '@/services/account/account.helper'

export const instance = axios.create({
	baseURL: process.env.SERVER_URL,
	headers: getContentType(),
})

instance.interceptors.request.use(config => {
	const token = getToken()

	if (config.headers && token) config.headers.Authorization = `Bearer ${token}`

	return config
})

instance.interceptors.response.use(
	config => config,
	error => {
		if (
			error.response.status === 401 ||
			errorCatch(error) === 'jwt expired' ||
			errorCatch(error) === 'jwt must be provided'
		) {
			removeFromStorage()
		}

		throw error
	}
)
