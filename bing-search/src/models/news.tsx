interface News {
  readLink: string,
	id: number,
	value: ValueNew[]
}

interface ValueNew {
	name: string,
	url: string
  description: string
	image: Image
}

interface Image {
	contentUrl: string
}