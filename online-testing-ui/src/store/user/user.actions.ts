import { removeFromStorage } from '@/services/account/account.helper'
import { AccountService } from '@/services/account/account.service'
import {
	IAuthResponse,
	IAuthUserResponse,
	ILogin,
	IRegister,
} from '@/store/user/user.interface'
import { createAsyncThunk } from '@reduxjs/toolkit'

export const register = createAsyncThunk<IAuthResponse, IRegister>(
	'account/register',
	async (data, thunkApi) => {
		try {
			const response = await AccountService.register(data)
			return response
		} catch (error) {
			return thunkApi.rejectWithValue(error)
		}
	}
)

export const login = createAsyncThunk<IAuthResponse, ILogin>(
	'account/login',
	async (data, thunkApi) => {
		try {
			const response = await AccountService.login(data)
			return response
		} catch (error) {
			return thunkApi.rejectWithValue(error)
		}
	}
)

export const logout = createAsyncThunk('account/logout', () => {
	removeFromStorage()
})
