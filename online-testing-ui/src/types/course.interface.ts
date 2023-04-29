export interface ICourse {
	code: string
	image: string | null
	name: string
	description: string | null
	section: string | null
	isDeleted: boolean
	dateCreated: Date
}

export interface ICreateCourse {
	name: string
	description: string | null
	section: string | null
}
