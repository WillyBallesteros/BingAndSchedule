import { FunctionComponent } from "react";
import { Card, CardBody, Heading, Image, Stack, Text } from "@chakra-ui/react";

interface IProps {
  pageData: Value,
}

const WebPageCard: FunctionComponent<IProps> = (props: IProps) => {
  const page = props.pageData;
  return (
    <Card maxW="sm" height={'500px'} margin={'15px'}>
      <CardBody>
        { (page.thumbnailUrl) ? <Image
          src={page.thumbnailUrl}
          alt={page.name}
          borderRadius="lg"
        />: null }
        <Stack mt="6" spacing="3">
          <Heading size="md">{page.name}</Heading>
          <Text>
            {page.snippet}
          </Text>
          <Text color="blue.600" fontSize="2xl">
            <a href={page.url}>{page.url}</a>
          </Text>
        </Stack>
      </CardBody>
    </Card>
  );
};

export default WebPageCard;
