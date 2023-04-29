import { createSlice } from '@reduxjs/toolkit'
import { IInitState, IUserState } from './user.interface'
import { login, logout, register } from './user.actions'
import { getFromLocalStorage } from '@/utils/local-storage'
import { decodeToken } from 'react-jwt'
import { IUser } from '@/types/user.interface'

const initialState: IInitState = {
	user: getFromLocalStorage('user'),
	isLoading: false,
}

export const userSlice = createSlice({
	name: 'user',
	initialState,
	reducers: {},
	extraReducers: builder => {
		builder
			.addCase(register.pending, state => {
				state.isLoading = true
			})
			.addCase(register.fulfilled, (state, { payload }) => {
				state.isLoading = false
				const user = decodeToken<IUserState>(payload.token)
				state.user = user || null
			})
			.addCase(register.rejected, state => {
				state.isLoading = false
			})
			.addCase(login.pending, state => {
				state.isLoading = true
			})
			.addCase(login.fulfilled, (state, { payload }) => {
				state.isLoading = false
				const user = decodeToken<IUserState>(payload.token)
				state.user = user || null
			})
			.addCase(login.rejected, state => {
				state.isLoading = false
			})
			.addCase(logout.fulfilled, state => {
				state.isLoading = false
				state.user = null
			})
	},
})
