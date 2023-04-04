import { useEffect, useState, FunctionComponent } from "react";
import apiClient from "../services/api-client";
import {
  Tab,
  TabIndicator,
  TabList,
  TabPanel,
  TabPanels,
  Tabs,
} from "@chakra-ui/react";
import WebPageCard from "./WebPageCard";
import ImageCard from "./ImageCard";
import NewCard from "./NewCard";
import VideoCard from "./VideoCard";

interface FetchResultsResponse {
  webPages: WebPages;
  images: Images;
  news: News;
  videos: Videos;
}

interface SearchProps {
  wordSearch: string;
}
const styles = {
  classFlex: {
    display: "grid",
    gridTemplateColumns: "repeat(4, 1fr)",
    gridTemplateRows: "repeat(3, 1fr)",
    gridColumnGap: "0px",
    gridRowGap: "0px",
  },
};

const ResultsGrid: FunctionComponent<SearchProps> = (props: SearchProps) => {
  const [searchResults, setSearchResults] = useState<FetchResultsResponse>();
  const [error, setError] = useState([]);

  useEffect(() => {
    if (props.wordSearch !== "") {
      apiClient
        .get<FetchResultsResponse>(
          `/search?count=10&mkt=en-US&q=${props.wordSearch}`
        )
        .then((res) => setSearchResults(res.data))
        .catch((err) => setError(err.message));
    }
  }, [props.wordSearch]);

  return (
    <Tabs position="relative" variant="unstyled">
      <TabList>
        <Tab>Web Pages</Tab>
        <Tab>Images</Tab>
        <Tab>News</Tab>
        <Tab>Videos</Tab>
      </TabList>
      <TabIndicator mt="-1.5px" height="2px" bg="blue.500" borderRadius="1px" />
      <TabPanels>
        <TabPanel>
          <div color="white" style={styles.classFlex}>
            {searchResults?.webPages?.value?.map((item) => (
              <WebPageCard pageData={item} />
            ))}
          </div>
        </TabPanel>
        <TabPanel className="">
          <div color="white" style={styles.classFlex}>
            {searchResults?.images?.value?.map((item) => (
              <ImageCard pageData={item} />
            ))}
          </div>
        </TabPanel>
        <TabPanel>
          <div color="white" style={styles.classFlex}>
            {searchResults?.news?.value?.map((item) => (
              <NewCard pageData={item} />
            ))}
          </div>
        </TabPanel>
        <TabPanel>
          <div color="white" style={styles.classFlex}>
            {searchResults?.videos?.value?.map((item) => (
              <VideoCard pageData={item} />
            ))}
          </div>
        </TabPanel>
      </TabPanels>
    </Tabs>
  );
};

export default ResultsGrid;
