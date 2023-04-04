interface WebPages {
  webSearchUrl: string,
	totalEstimatedMatches: number,
	value: Value[]
}

interface Value {
  id: string,
	name: string,
	url: string,
	thumbnailUrl: string
  snippet: string
}