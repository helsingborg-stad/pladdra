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
