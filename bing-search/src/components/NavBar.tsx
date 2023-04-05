import {
  Box,
  Button,
  HStack,
  Image,
  Input,
  InputGroup,
  SimpleGrid,
  Stack,
  Text,
  InputRightElement,
} from "@chakra-ui/react";
import logo from "../assets/bing.jpg";
import { Dispatch, FunctionComponent, SetStateAction, useState } from "react";

interface IProps {
  setWordSearch: Dispatch<SetStateAction<string>>;
}

const NavBar: FunctionComponent<IProps> = (props: IProps) => {
  const [textToSearch, setTextToSearch] = useState<string>("");

  const handleClick = () => {
    props.setWordSearch(textToSearch);
  };

  return (
    <>
      <SimpleGrid columns={3} spacing={10}>
        <Box height="20%">
          <HStack spacing={3}>
            <Image src={logo} boxSize="60px" />
            <Text>Microsoft Bing</Text>
          </HStack>
        </Box>
        <Box height="60%" padding={"12px"}>
          <Stack spacing={3}>
            <InputGroup size="md">
              <Input
                pr="4.5rem"
                placeholder="Search in Bing..."
                onChange={(e) => setTextToSearch(e.currentTarget.value)}
                onKeyPress={(e) => {
                  if (e.key === "Enter") {
                    handleClick();
                  }
                }}
              />
              <InputRightElement width="4.5rem">
                <Button
                  h="1.75rem"
                  size="sm"
                  colorScheme="blue"
                  onClick={handleClick}
                >
                  Search
                </Button>
              </InputRightElement>
            </InputGroup>
          </Stack>
        </Box>
        <Box height="20%"></Box>
      </SimpleGrid>
    </>
  );
};

export default NavBar;
