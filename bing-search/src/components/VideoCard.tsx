import { FunctionComponent } from "react";
import { Card, CardBody, Heading, Image, Stack, Text } from "@chakra-ui/react";

interface IProps {
  pageData: ValueNew,
}

const VideoCard: FunctionComponent<IProps> = (props: IProps) => {
  const news = props.pageData;
  return (
    <Card maxW="sm" height={'500px'} margin={'15px'}>
      <CardBody>
        { (news?.thumbnailUrl) ? <Image
          src={news?.thumbnailUrl}
          alt={news.name}
          borderRadius="lg"
        />: null }
        <Stack mt="6" spacing="3">
          <Heading size="md">{news.name}</Heading>
          <Text>
            {news.description}
          </Text>
          <Text color="blue.600" fontSize="2xl">
            <a href={news.contentUrl}>{news.contentUrl}</a>
          </Text>
        </Stack>
      </CardBody>
    </Card>
  );
};

export default VideoCard;
