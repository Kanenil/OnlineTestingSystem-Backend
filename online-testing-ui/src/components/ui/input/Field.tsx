import React, { forwardRef } from 'react'
import { IField } from './field.interface'
import cn from 'clsx'

const Field = forwardRef<HTMLInputElement, IField>(
	(
		{ placeholder, error, Icon, className, type = 'text', style, ...rest },
		ref
	) => {
		return (
			<div className={cn('mb-4', className)} style={style}>
				<label>
					<span className='mb-1 block'>
						{Icon && <Icon className='mr-3' />}
						{placeholder}
					</span>
					<input
						ref={ref}
						type={type}
						placeholder={placeholder}
						className={cn(
							'px-4 py-2 w-full outline-none border border-gray-300 border-solid focus:border-orange-400 transition-all placeholder:font-light rounded-lg',
							{ 'border-red-400': !!error }
						)}
						{...rest}
					/>
				</label>
				{error && <div className='text-red-400 text-sm mt-1'>{error}</div>}
			</div>
		)
	}
)

Field.displayName = 'Field'

export default Field
