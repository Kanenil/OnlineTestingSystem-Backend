import { NextPage } from 'next'
import Meta from '@/components/ui/Meta'
import Button from '@/components/ui/button/Button'
import Heading from '@/components/ui/Heading'
import { useAuth } from '@/hooks/useAuth'
import { useActions } from '@/hooks/useActions'
import { SubmitHandler, useForm } from 'react-hook-form'
import { ILogin } from '@/store/user/user.interface'
import Field from '@/components/ui/input/Field'
import { validEmail } from './valid-email'
import Loader from '@/components/ui/Loader'
import Link from 'next/link'
import { useAuthRedirect } from '@/hooks/useAuthRedirect'

const Login: NextPage = () => {
	useAuthRedirect()

	const { isLoading } = useAuth()
	const { login } = useActions()

	const {
		register,
		handleSubmit,
		formState: { errors },
		reset,
	} = useForm<ILogin>({
		mode: 'onChange',
	})

	const onSubmit: SubmitHandler<ILogin> = data => {
		login(data)
		reset()
	}

	return (
		<Meta title='Login'>
			<section className='flex h-screen'>
				<form
					onSubmit={handleSubmit(onSubmit)}
					className='rounded-lg bg-white shadow-sm p-8 m-auto'
				>
					<Heading className='capitalize text-center'>Login</Heading>

					{isLoading && <Loader />}

					<Field
						{...register('email', {
							required: 'Email is required',
							pattern: {
								value: validEmail,
								message: 'Please enter a valid email address',
							},
						})}
						placeholder='Email'
						error={errors.email?.message}
					/>
					<Field
						{...register('password', {
							required: 'Password is required',
							minLength: {
								value: 6,
								message: 'Min length should more 6 symbols',
							},
						})}
						type='password'
						placeholder='Password'
						error={errors.password?.message}
					/>
					<Button variant='orange'>Login</Button>
					<div>
						<Link
							href='/account/register'
							className='inline-block opacity-50 mt-3'
						>
							Register
						</Link>
					</div>
				</form>
			</section>
		</Meta>
	)
}

export default Login
