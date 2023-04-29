import { FC, PropsWithChildren } from 'react'
import { TypeComponentAuthFields } from './auth-page.types'
import { useAuth } from '@/hooks/useAuth'
import { useRouter } from 'next/router'

const CheckRole: FC<PropsWithChildren<TypeComponentAuthFields>> = ({
	Component: { isOnlyUser },
	children,
}) => {
	const { user } = useAuth()

	const router = useRouter()

	if (user && isOnlyUser) return <>{children}</>

	router.pathname !== '/account/login' && router.replace('/account/login')
	return null
}

export default CheckRole
