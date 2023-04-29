import { instance } from '@/api/api.interceptor'
import { IBaseResponse } from '@/types/base.interface'
import { ICourse, ICreateCourse } from '@/types/course.interface'

const COURSES = 'courses'

export const CoursesService = {
	async getAll() {
		return instance<ICourse[]>({
			url: COURSES,
			method: 'GET',
		})
	},

	async getById(id: number | string) {
		return instance<ICourse>({
			url: `${COURSES}/${id}`,
			method: 'GET',
		})
	},

	async create(data: ICreateCourse) {
		return instance<IBaseResponse>({
			url: COURSES,
			method: 'POST',
			data,
		})
	},

	async update(data: ICourse) {
		return instance({
			url: COURSES,
			method: 'PUT',
			data,
		})
	},

	async delete(id: number) {
		return instance({
			url: `${COURSES}/${id}`,
			method: 'DELETE',
		})
	},
}
