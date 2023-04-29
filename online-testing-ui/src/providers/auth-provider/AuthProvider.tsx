import { FC, PropsWithChildren, useEffect } from 'react'
import { TypeComponentAuthFields } from './auth-page.types'
import dynamic from 'next/dynamic'
import { useAuth } from '@/hooks/useAuth'
import { useActions } from '@/hooks/useActions'
import { useRouter } from 'next/router'
import { getToken } from '@/services/account/account.helper'

const DynamicCheckRole = dynamic(() => import('./CheckRole'), { ssr: false })

const AuthProvider: FC<PropsWithChildren<TypeComponentAuthFields>> = ({
	Component: { isOnlyUser },
	children,
}) => {
	const { user } = useAuth()
	const { logout } = useActions()

	const { pathname } = useRouter()

	useEffect(() => {
		const token = getToken()
		if (!token && user) logout()
	}, [pathname])

	return isOnlyUser ? (
		<DynamicCheckRole Component={{ isOnlyUser }} children={children} />
	) : (
		<>{children}</>
	)
}

export default AuthProvider
