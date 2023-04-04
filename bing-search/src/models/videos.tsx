interface Videos {
  readLink: string,
	id: number,
  webSearchUrl: string,
	value: ValueNew[]
}

interface ValueNew {
	name: string,
	thumbnailUrl: string
  description: string,
  contentUrl: string,
  webSearchUrl: string
}