import { ButtonHTMLAttributes, FC, PropsWithChildren } from 'react'
import cn from 'clsx'

interface IButton extends ButtonHTMLAttributes<HTMLButtonElement> {
	variant: 'white' | 'orange'
}

const Button: FC<PropsWithChildren<IButton>> = ({
	children,
	className,
	variant,
	...rest
}) => {
	return (
		<button
			{...rest}
			className={cn(
				'rounded-xl font-medium shadow px-10 py-2',
				{
					'text-white bg-orange-400': variant === 'orange',
					'text-orange-400 bg-white': variant === 'white',
				},
				className
			)}
		>
			{children}
		</button>
	)
}

export default Button
