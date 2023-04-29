export const getFromLocalStorage = (key: string) => {
	if (typeof localStorage === 'object') {
		const ls = localStorage.getItem(key)
		return ls ? JSON.parse(ls) : null
	}
	return null
}
