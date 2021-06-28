import prettyBytes from "pretty-bytes";

export const humanReadableToBytes = (humanReadable: string): number => {
  const units: Record<string, any> = {
    B: (n: number) => n / 1000,
    kB: (n: number) => n,
    MB: (n: number) => n * 1000,
    GB: (n: number) => n * 1000 * 1000,
    TB: (n: number) => n * 1000 * 1000 * 1000,
  };

  const [size, unit] = humanReadable.replace(",", "").split(" ");

  return units[unit](Number(size));
};

export const bytesToHumanReadable = (
  bytes: number,
  options: Record<string, any> = { minimumFractionDigits: 3 }
): string => prettyBytes(bytes, options);

export const parseExtension = (s: string): string | null =>
  s.split(".").pop() ?? null;

export default { humanReadableToBytes, bytesToHumanReadable, parseExtension };
