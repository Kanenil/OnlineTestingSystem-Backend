import Heading from '@/components/ui/Heading'
import Meta from '@/components/ui/Meta'
import { NextPage } from 'next'
import Link from 'next/link'

interface Props {}

const Home: NextPage<Props> = ({}) => {
	return (
		<Meta title='Home'>
			<Heading>Home</Heading>
			<Link href='/account/login'>Login</Link>
		</Meta>
	)
}

export default Home
