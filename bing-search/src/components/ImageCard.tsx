import { FunctionComponent } from "react";
import { Card, CardBody, Heading, Image, Stack, Text } from "@chakra-ui/react";

interface IProps {
  pageData: ValueImage,
}

const ImageCard: FunctionComponent<IProps> = (props: IProps) => {
  const image = props.pageData;
  return (
    <Card maxW="sm" height={'auto'} margin={'15px'}>
      <CardBody>
        { (image.thumbnailUrl) ? <Image
          src={image.thumbnailUrl}
          alt={image.name}
          borderRadius="lg"
        />: null }
        <Stack mt="6" spacing="3">
          <Heading size="md">{image.name}</Heading>
          <Text>
            {image.contentUrl}
          </Text>
          <Text color="blue.600" fontSize="2xl">
            <a href={image.contentUrl}>{image.contentUrl}</a>
          </Text>
        </Stack>
      </CardBody>
    </Card>
  );
};

export default ImageCard;
