interface Images {
  webSearchUrl: string,
	id: number,
	value: ValueImage[]
}

interface ValueImage {
	name: string,
	thumbnailUrl: string
  contentUrl: string
}