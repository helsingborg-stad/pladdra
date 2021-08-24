/* tslint:disable */
/* eslint-disable */
// this is an auto generated file. This will be overwritten

export const getAsset = /* GraphQL */ `
  query GetAsset($id: ID!) {
    getAsset(id: $id) {
      id
      name
      type
      fileFormat
      fileName
      fileSize
      file {
        bucket
        key
        region
      }
      description
      createdAt
      updatedAt
    }
  }
`;
export const listAssets = /* GraphQL */ `
  query ListAssets(
    $filter: ModelAssetFilterInput
    $limit: Int
    $nextToken: String
  ) {
    listAssets(filter: $filter, limit: $limit, nextToken: $nextToken) {
      items {
        id
        name
        type
        fileFormat
        fileName
        fileSize
        file {
          bucket
          key
          region
        }
        description
        createdAt
        updatedAt
      }
      nextToken
    }
  }
`;
export const assetsByFileFormat = /* GraphQL */ `
  query AssetsByFileFormat(
    $fileFormat: AssetFileFormat
    $createdAtUpdatedAt: ModelAssetByFileFormatCompositeKeyConditionInput
    $sortDirection: ModelSortDirection
    $filter: ModelAssetFilterInput
    $limit: Int
    $nextToken: String
  ) {
    assetsByFileFormat(
      fileFormat: $fileFormat
      createdAtUpdatedAt: $createdAtUpdatedAt
      sortDirection: $sortDirection
      filter: $filter
      limit: $limit
      nextToken: $nextToken
    ) {
      items {
        id
        name
        type
        fileFormat
        fileName
        fileSize
        file {
          bucket
          key
          region
        }
        description
        createdAt
        updatedAt
      }
      nextToken
    }
  }
`;
export const getBlock = /* GraphQL */ `
  query GetBlock($id: ID!) {
    getBlock(id: $id) {
      id
      createdAt
      updatedAt
      workspaceID
      assetID
      position {
        x
        y
        z
      }
      rotation {
        x
        y
        z
        w
      }
      owner
    }
  }
`;
export const listBlocks = /* GraphQL */ `
  query ListBlocks(
    $filter: ModelBlockFilterInput
    $limit: Int
    $nextToken: String
  ) {
    listBlocks(filter: $filter, limit: $limit, nextToken: $nextToken) {
      items {
        id
        createdAt
        updatedAt
        workspaceID
        assetID
        position {
          x
          y
          z
        }
        rotation {
          x
          y
          z
          w
        }
        owner
      }
      nextToken
    }
  }
`;
export const getWorkspace = /* GraphQL */ `
  query GetWorkspace($id: ID!) {
    getWorkspace(id: $id) {
      id
      name
      createdAt
      updatedAt
      description
      blocks {
        items {
          id
          createdAt
          updatedAt
          workspaceID
          assetID
          owner
        }
        nextToken
      }
      owner
    }
  }
`;
export const listWorkspaces = /* GraphQL */ `
  query ListWorkspaces(
    $filter: ModelWorkspaceFilterInput
    $limit: Int
    $nextToken: String
  ) {
    listWorkspaces(filter: $filter, limit: $limit, nextToken: $nextToken) {
      items {
        id
        name
        createdAt
        updatedAt
        description
        blocks {
          nextToken
        }
        owner
      }
      nextToken
    }
  }
`;
